import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ResponseDto, ProductDetailDto, CartItemDto, ServiceResponse } from '../models/model';
@Injectable({
  providedIn: 'root'
})
export class PublicService {
  private apiUrl = 'https://localhost:44370/api/';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<ProductDetailDto[]> {
    const params = {

    };

    return this.http.get<ResponseDto>(this.apiUrl + 'ProductDetail/PGetProductDetail', { params })
      .pipe(map(response => response.result));
  }
  getProductById(productId: string): Observable<ProductDetailDto> {
    const params = {

    };

    return this.http.get<ResponseDto>(`${this.apiUrl}ProductDetail/GetById?id=${productId}`, { params })
      .pipe(map(response => response.result));
  }
  getCartByUser(): Observable<CartItemDto[]> {
    const currentUserString = localStorage.getItem('currentUser');
    if (currentUserString) {
      const currentUser = JSON.parse(currentUserString);
      if (currentUser.username) {
        const params = {

        };
        return this.http.post<ResponseDto>(this.apiUrl + `Cart/GetCartByUser?username=${currentUser.username}`, { params })
          .pipe(map(response => response.result));
      }

    }
    const params = {

    };

    return this.http.post<ResponseDto>(this.apiUrl + 'Cart/GetCartByUser?username=kieumy', { params })
      .pipe(map(response => response.result));
  }
  addProductToCart(username: string, productId: string): Observable<ServiceResponse> {
    const params = {
      username: username,
      idProductDetail: productId
    };
    return this.http.post<ServiceResponse>(`${this.apiUrl}Cart/AddToCart`, params);
  }
  deleteCartDetai(Id: number): Observable<ServiceResponse> {
    const params = {
    };
    return this.http.delete<ServiceResponse>(`${this.apiUrl}Cart/DeleteCartDetail?Id=${Id}`, params);
  }
  updateQuantityCartItem(quantity: number, idCartDetail: number): Observable<ServiceResponse> {
    const params = {
      quantity: quantity,
      idCartDetail: idCartDetail,
    };
    return this.http.post<ServiceResponse>(`${this.apiUrl}Cart/UpdateQuantity`, params);
  }
}