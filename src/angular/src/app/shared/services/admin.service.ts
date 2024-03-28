import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ResponseDto, ProductDetailDto, VoucherDto, PagedResultDto,ServiceResponse} from '../models/model';
import { tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'https://localhost:44370/api/';
  private token!: string;
  constructor(private http: HttpClient) { }

  getVouchers(pageNumber: number, pageSize: number, sorting: string): Observable<PagedResultDto<any>> {
    const url = `${this.apiUrl}Voucher/GetPaged`;
    const body = {
      maxResultCount: pageSize,
      skipCount: (pageNumber - 1) * pageSize,
      sorting: sorting
    };
    return this.http.post<PagedResultDto<any>>(url, body);
  }
 
}
