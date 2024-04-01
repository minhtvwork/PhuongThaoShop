import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ResponseDto, ProductDetailDto, VoucherDto, PagedResultDto,ServiceResponse} from '../models/model';
import { tap } from 'rxjs/operators';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'https://localhost:44370/api/';
  private token!: string;
  constructor(private http: HttpClient,private accountService: AccountService) { }

  getVouchers(pageNumber: number, pageSize: number, sorting: string): Observable<PagedResultDto<any>> {
    const url = `${this.apiUrl}Voucher/GetPaged`;
    const token = this.accountService.getAccessToken();
    console.log(token)
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    const body = {
      maxResultCount: pageSize,
      skipCount: (pageNumber - 1) * pageSize,
      sorting: sorting
    };
    return this.http.post<PagedResultDto<any>>(url, body,{ headers: headers });
  }
 
}
