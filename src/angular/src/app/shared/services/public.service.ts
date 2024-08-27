import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ResponseDto, ProductDetailDto, CartItemDto, ServiceResponse, PBillCreateCommand, PBillGetByCodeQueryDto, ApiResult } from '../models/model';
import { AccountService } from 'src/app/shared/services/account.service';
import { AppConstants } from 'src/app/constants';
@Injectable({
  providedIn: 'root'
})
export class PublicService {
  private apiUrl = AppConstants.API_URL;

  constructor(private http: HttpClient, private accountService: AccountService) { }
  // getListProducts(page: number, pageSize: number, filters: any): Observable<any> {
  //   const body = {
  //     page: page,
  //     pageSize: pageSize,
  //     filters
  //   };

  //   return this.http.post<any>(this.apiUrl+'Public/GetListProduct', body);
  // }
  getListProducts(page: number, pageSize: number, keywords: string, manufacturer?: number, productType?: string, ram?: number, cpu?: number, cardVGA?: number, hardDrive?: string, screen?: string, price?: number, sortBy?: number): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Public/GetListProduct`, {
      page,
      pageSize,
      keywords,
      manufacturer,
      //  productType,
      ram,
      cpu,
      cardVGA,
      hardDrive,
      screen,
      price,
      sortBy

    });
  }
  getProducts(): Observable<ProductDetailDto[]> {
    const params = {

    };

    return this.http.get<ResponseDto>(this.apiUrl + 'ProductDetail/PGetProductDetail', { params })
      .pipe(map(response => response.result));
  }
  // getProductById(productId: string): Observable<ProductDetailDto> {
  //   const params = {

  //   };

  //   return this.http.get<ResponseDto>(`${this.apiUrl}ProductDetail/GetById?id=${productId}`, { params })
  //     .pipe(map(response => response.result));
  // }
  getProductById(id: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Public/GetProductById`, {
      id
    });
  }
  getAddress(userId: number): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Address/GetByUserId`, {
      userId
    });
  }
  createOrUpdateAddress(id?: number, addressName?: string, userEntityId?: number
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Address/CreateOrUpdate`, {
      id,addressName, userEntityId
    });
  }
 
  getCartByUser(): Observable<CartItemDto[]> {
    const currentUserString = localStorage.getItem('currentUser');
    if (currentUserString) {
      const currentUser = JSON.parse(currentUserString);
      if (currentUser.userName) {
        const params = {

        };
        return this.http.post<ResponseDto>(this.apiUrl + `Cart/GetCartByUser?userName=${currentUser.userName}`, { params })
          .pipe(map(response => response.result));
      }

    }
    const params = {

    };

    return this.http.post<ResponseDto>(this.apiUrl + 'Cart/GetCartByUser?userName=kieumy', { params })
      .pipe(map(response => response.result));
  }
  addProductToCart(userName: string, productId: string, quantity: number): Observable<ServiceResponse> {
    const params = {
      userName: userName,
      idProductDetail: productId,
      quantity: quantity
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
  getListVouchers(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}Public/GetListVoucher`);
  }
  createBill(request: PBillCreateCommand): Observable<ApiResult<PBillGetByCodeQueryDto>> {
    // request.userName = this.accountService.getuserName();
    request.userName = this.accountService.getuserName();
    const cartItemsString = localStorage.getItem('cartItems');
    var addressAll = '';
    if (cartItemsString) {
      request.cartItem = JSON.parse(cartItemsString);
      
    }
    if(this.accountService.getuserName()){
      addressAll = request.address;
    }
    else {
      addressAll = (request.address || '') +', '+ (request.communeText || '') +', '+ (request.districtText || '') +', '+ (request.provinceText || '')
    }
    console.log(request);

    const params = {
      fullName: request.fullName,
      userName: request.userName,
      phoneNumber: request.phoneNumber,
      address: addressAll ,
      notes: request.notes,
      codeVoucher: request.codeVoucher,
      payment: request.payment,
      cartItem: request.cartItem
    };

    return this.http.post<ApiResult<PBillGetByCodeQueryDto>>(`${this.apiUrl}Public/CreateBill`, params);
  }
  getBillByInvoiceCode(invoiceCode: string): Observable<any> {
    const params = {
      invoiceCode: invoiceCode,
    };

    return this.http.post<any>(`${this.apiUrl}Public/GetBill`, params);
  }
  getCountById(id: number): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}ProductDetail/GetCountById`, {
      id
    });
  }
  getProvinces(): Observable<any> {
    return this.http.get(`https://vapi.vnappmob.com/api/province/`);
  }
  getDistricts(provinceId: string): Observable<any> {
    return this.http.get(`https://vapi.vnappmob.com/api/province/district/${provinceId}`);
  }
  getCommunes(districtId: string): Observable<any> {
    return this.http.get(`https://vapi.vnappmob.com/api/province/ward/${districtId}`);
  }
  getBillByUserId(userId: number): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Bill/BillGetByUserId`, {
      userId
    });
  }
  getUserById(id: number): Observable<any> {
    return this.http.post(`${this.apiUrl}User/GetById`, { id });
  }

  // createOrUpdateUser(user: any): Observable<any> {
  //   var fullName = user.fullName;
  //   var phoneNumber = user.phoneNumber;
  //   return this.http.post(`${this.apiUrl}User/CreateOrUpdate`,{phoneNumber});
  // }
  createOrUpdateUser(id?: number, fullName?: string, phoneNumber?: string,email?: string
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}User/CreateOrUpdate`, {
     id,fullName,phoneNumber,email
    });
  }
}