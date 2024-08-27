
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, map, of } from 'rxjs';
import { ResponseDto, ProductDetailDto, VoucherDto, PagedResultDto, ServiceResponse } from '../models/model';
import { tap } from 'rxjs/operators';
import { catchError } from 'rxjs/operators';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private apiUrl = 'https://localhost:44302/api/';
  private token!: string;
  constructor(private http: HttpClient) { }

  login(userName: string, password: string): Observable<any> {
    const url = `${this.apiUrl}Account/Login`;
    const body = { userName: userName, Password: password };
    return this.http.post<any>(url, body).pipe(
      map(response => {
        if (response && response.accessToken) {
          localStorage.setItem('currentUser', JSON.stringify({
            id: response.id,
            userName: response.userName,
            role: response.roleName,
            accessToken: response.accessToken,
            isAdmin: response.isAdmin
          }));
          return response;
        } else {
          throw new Error('Invalid response from server');
        }
      })
    );
  }

  getCurrentUser(): any {
    const currentUser = localStorage.getItem('currentUser');
    return currentUser ? JSON.parse(currentUser) : null;
  }
  getuserName(): string {
    const currentUser = localStorage.getItem('currentUser');
    return currentUser ? JSON.parse(currentUser).userName : null;
  }
  getUserId(): number {
    const currentUser = localStorage.getItem('currentUser');
    return currentUser ? JSON.parse(currentUser).id : null;
  }
  getAccessToken(): string {
    const currentUser = localStorage.getItem('currentUser');
    return currentUser ? JSON.parse(currentUser).accessToken : null;
  }
  isLoggedIn(): boolean {
    return !!localStorage.getItem('currentUser');
  }

  logout(): void {
    localStorage.removeItem('currentUser');
  }
  checkIsAdmin(): Promise<boolean> {
    const url = `${this.apiUrl}Account/isAdmin`;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.getAccessToken()}`
    });

    return this.http.post<boolean>(url, {}, { headers }).pipe(
      map(response => response === true),
      catchError(error => {
        console.error('Error checking admin status:', error);
        return of(false);
      })
    ).toPromise() as Promise<boolean>;
  }

  register(model: any): Observable<any> {
    return this.http.post(`${this.apiUrl}Account/register`, model, { responseType: 'text' });
  }
  checkUserPermission(token: string): Promise<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}Account/check-permission`,
      { token: token },
      {
        headers: {
          'Content-Type': 'application/json'
        }
      }).toPromise()
      .then(response => response !== undefined && response !== null ? response : false)
      .catch(error => {
        console.error('Error checking user permission', error);
        return true;
      });
  }
  getUserRoles(): Observable<string[]> {
    const token = this.getAccessToken();
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    let username = this.getuserName();
    const params = { username };
    return this.http.get<string[]>(`${this.apiUrl}Account/GetUserRoles`, { headers, params });
  }
}
