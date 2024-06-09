import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ResponseDto, ProductDetailDto, VoucherDto, PagedResultDto,ServiceResponse, PagedRequest} from '../models/model';
import { tap } from 'rxjs/operators';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'https://localhost:44302/api/';
  private token!: string;
  constructor(private http: HttpClient,private accountService: AccountService) { }

  // getVouchers(pageNumber: number, pageSize: number, sorting: string): Observable<PagedResultDto<any>> {
  //   const url = `${this.apiUrl}Voucher/GetPaged`;
  //   const token = this.accountService.getAccessToken();
  //   const headers = new HttpHeaders({
  //     'Content-Type': 'application/json',
  //     'Authorization': `Bearer ${token}`
  //   });
  //   const body = {
  //     maxResultCount: pageSize,
  //     skipCount: (pageNumber - 1) * pageSize,
  //     sorting: sorting
  //   };
  //   return this.http.post<PagedResultDto<any>>(url, body,{ headers: headers });
  // }
  getPageVouchers(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Voucher/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  
  getListRam(): Observable<any> {
    return this.http.get(`${this.apiUrl}GetList`);
  }

  getPagedRam(request: PagedRequest): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post<any>(`${this.apiUrl}Ram/GetPaged`, request,{ headers: headers });
  }

  getByRamId(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}Ram/GetById?id=${id}`);
  }

  createOrUpdateRam(objDto: any): Observable<any> {
    console.log(objDto);
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Ram/CreateOrUpdateAsync`, objDto,{ headers: headers });
  }

  deleteRam(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Ram/Delete?id=${id}`,null,{ headers: headers });
  }
  // role
  getListRole(): Observable<any> {
    return this.http.get(`${this.apiUrl}GetList`);
  }

  getPagedRole(request: PagedRequest): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post<any>(`${this.apiUrl}Role/GetPaged`, request,{ headers: headers });
  }

  getByRoleId(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}Role/GetById?id=${id}`);
  }

  createOrUpdateRole(objDto: any): Observable<any> {
    console.log(objDto);
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Role/CreateOrUpdateAsync`, objDto,{ headers: headers });
  }

  deleteRole(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Role/Delete?id=${id}`,null,{ headers: headers });
  }
}
