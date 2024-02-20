import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ResponseDto, ProductDetailDto} from '../../app/models/model';
@Injectable({
  providedIn: 'root'
})
export class PublicService {
  private apiUrl = 'https://localhost:44370/api/';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<ProductDetailDto[]> {
    const params = {

    };

    return this.http.get<ResponseDto>(this.apiUrl+'ProductDetail/PGetProductDetail', { params })
      .pipe(map(response => response.result));
  }
  getProductById(productId: string): Observable<ProductDetailDto> {
    const params = {

    };

    return this.http.get<ResponseDto>(`${this.apiUrl}ProductDetail/GetById?id=${productId}`, { params })
      .pipe(map(response => response.result));
  }
  
}