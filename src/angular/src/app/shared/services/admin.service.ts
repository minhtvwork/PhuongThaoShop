import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ResponseDto, ProductDetailDto, VoucherDto, PagedResultDto, ServiceResponse, PagedRequest } from '../models/model';
import { tap } from 'rxjs/operators';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'https://localhost:44302/api/';
  private token!: string;
  constructor(private http: HttpClient, private accountService: AccountService) { }


  getPageBill(page: number, pageSize: number, keywords: string, status: number,type: number): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Bill/GetPage`, {
      page,
      pageSize,
      keywords,
      status,
      type
    });
  }
  getPageBillV2(page: number, pageSize: number, keywords: string, status: number,type: number): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Bill/GetPage2`, {
      page,
      pageSize,
      keywords,
      status,
      type
    });
  }
  getBillDetailsByBillId(billId: number): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}BillDetail/GetByBillId`, {
      billId
    });
  }
  getPageVouchers(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Voucher/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  getPageProductDetail(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}ProductDetail/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  getListRam(): Observable<any> {
    return this.http.get(`${this.apiUrl}Ram/GetAll`);
  }

  getListProductDetail(): Observable<any> {
    return this.http.get(`${this.apiUrl}ProductDetail/GetList`);
  }
  getListProduct(): Observable<any> {
    return this.http.get(`${this.apiUrl}Product/GetAll`);
  }
  getListProductType(): Observable<any> {
    return this.http.get(`${this.apiUrl}ProductType/GetAll`);
  }
  getListManufacturer(): Observable<any> {
    return this.http.get(`${this.apiUrl}Manufacturer/GetAll`);
  }
  getListDiscount(): Observable<any> {
    return this.http.get(`${this.apiUrl}Discount/GetAll`);
  }

  getListCpu(): Observable<any> {
    return this.http.get(`${this.apiUrl}Cpu/GetAll`);
  }
  getListCardVGA(): Observable<any> {
    return this.http.get(`${this.apiUrl}CardVGA/GetAll`);
  }
  getListHardDrive(): Observable<any> {
    return this.http.get(`${this.apiUrl}HardDrive/GetAll`);
  }
  getListScreen(): Observable<any> {
    return this.http.get(`${this.apiUrl}Screen/GetAll`);
  }
  getListColor(): Observable<any> {
    return this.http.get(`${this.apiUrl}Color/GetAll`);
  }
  getListSerial(): Observable<any> {
    return this.http.get(`${this.apiUrl}Serial/GetAll`);
  }
  getListSerialByCodeProductDetail(codeProductDetail?: string): Observable<any> {
    return this.http.post(`${this.apiUrl}Serial/GetByCodeProductDetail`, { codeProductDetail });
  }
  getListImage(): Observable<any> {
    return this.http.get(`${this.apiUrl}Images/GetAll`);
  }
  getBestSellers(): Observable<any> {
    return this.http.get(`${this.apiUrl}Statistics/GetBestSellers`);
  }

  deleteBill(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Bill/Delete`, { id }, { headers: headers });
  }
  getBillNotification(): Observable<any> {
    return this.http.get(`${this.apiUrl}Bill/BillNotification`);
  }
  getBillById(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Bill/GetById`, { id }, { headers: headers });
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
    return this.http.post<any>(`${this.apiUrl}Role/GetPaged`, request, { headers: headers });
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
    return this.http.post(`${this.apiUrl}Role/CreateOrUpdateAsync`, objDto, { headers: headers });
  }
  createOrUpdateBill(id?: number, fullName?: string, address?: string, phoneNumber?: string, payment?: number, isPayment?: number, status?: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const crUserId = this.accountService.getUserId();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Bill/BillCreateOrUpdate`, { id, address, fullName, phoneNumber, payment, isPayment, status, crUserId });
  }
  createOrUpdateBillDetail(id?: number, billEntityId?: number, codeProductDetail?: string, quantity?: number
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}BillDetail/CreateOrUpdate`, {
      id, billEntityId, codeProductDetail, quantity
    });
  }
  deleteBillDetail(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}BillDetail/Delete`, { id }, { headers: headers });
  }
  createOrUpdateProductDetail(id?: number, code?: string, description?: string, price?: number, upgrade?: string, productEntityId?: number,
    colorEntityId?: number, ramEntityId?: number, cpuEntityId?: number, hardDriveEntityId?: number, screenEntityId?: number,
    cardVGAEntityId?: number, discountId?: number, status?: number
  ): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}ProductDetail/CreateOrUpdate`, {
      id, code, description, price, upgrade, productEntityId, colorEntityId, ramEntityId,
      cpuEntityId, hardDriveEntityId, screenEntityId, cardVGAEntityId, discountId, status
    });
  }
  deleteProductDetail(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}ProductDetail/Delete`, { id }, { headers: headers });
  }
  updateSerial(ids?: [number], billDetailEntityId?: number): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Serial/Update`, {
      ids, billDetailEntityId
    });
  }

  deleteRole(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Role/Delete?id=${id}`, null, { headers: headers });
  }
  uploadImage(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.apiUrl}image/upload`, formData);
  }
  getPageImage(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Images/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }

  // Method CRUD Basic

  getPageSerial(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Serial/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateSerial(id?: number, serialNumber?: string, productDetailEntityId?: number, status?: number
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Serial/CreateOrUpdate`, {
      id, serialNumber, productDetailEntityId, status
    });
  }
  deleteSerial(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Serial/Delete`, { id }, { headers: headers });
  }
  getPageProduct(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Product/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateProduct(id?: number, name?: string, manufacturerEntityId?: number, productTypeEntityId?: number
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Product/CreateOrUpdate`, {
      id, name,manufacturerEntityId,productTypeEntityId
    });
  }
  deleteProduct(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Product/Delete`, { id }, { headers: headers });
  }
  getPageVoucher(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Voucher/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateVoucher(id?: number, maVoucher?: string,tenVoucher?: string,startDay?: Date, endDay?:Date,giaTri?: number,soLuong?:number, status?: number
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Voucher/CreateOrUpdate`, {
      id,maVoucher, tenVoucher,startDay,endDay,giaTri,soLuong, status
    });
  }
  deleteVoucher(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Voucher/Delete`, { id }, { headers: headers });
  }
  getPageCpu(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Cpu/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateCpu(id?: number, ma?: string, ten?: string, 
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Cpu/CreateOrUpdate`, {
      id, ma, ten
    });
  }
  deleteCpu(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Cpu/Delete`, { id }, { headers: headers });
  }
  getPageRam(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Ram/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateRam(id?: number, ma?: string, thongSo?: string, 
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Ram/CreateOrUpdate`, {
      id, ma, thongSo
    });
  }
  deleteRam(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Ram/Delete`, { id }, { headers: headers });
  }
  getPageProductImage(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}ProductDetailImage/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateProductImage(id?: number, productDetailId? :number, imageId?:number, isIndex?: boolean
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}ProductDetailImage/CreateOrUpdate`, {
      id, productDetailId, imageId,isIndex
    });
  }
  deleteProductImage(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}ProductDetailImage/Delete`, { id }, { headers: headers });
  }
  deleteImage(id: number,url: string): Observable<any> {
    const params = new HttpParams()
    .set('id', id.toString())
    .set('url', url);
    return this.http.delete(`${this.apiUrl}Images/delete`, { params });
  }

  getPageCardVGA(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}CardVGA/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateCardVGA(id?: number, ma?: string, ten?: string, thongSo?: string
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}CardVGA/CreateOrUpdate`, {
      id, ma, ten, thongSo
    });
  }
  deleteCardVGA(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}CardVGA/Delete`, { id }, { headers: headers });
  }
  getPageHardDrive(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}HardDrive/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateHardDrive(id?: number, ma?: string,thongSo?: string
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}HardDrive/CreateOrUpdate`, {
      id, ma,thongSo
    });
  }
  deleteHardDrive(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}HardDrive/Delete`, { id }, { headers: headers });
  }

  getPageScreen(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Screen/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateScreen(id?: number, ma?: string, ten?: string, thongSo?: string
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Screen/CreateOrUpdate`, {
      id, ma, ten, thongSo
    });
  }
  deleteScreen(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Screen/Delete`, { id }, { headers: headers });
  }
  getPageProductType(page: number, pageSize: number, keywords: string): Observable<any> {
    const token = this.accountService.getAccessToken();
    return this.http.post<any>(`${this.apiUrl}ProductType/GetPage`, {
      page,
      pageSize,
      keywords
    }, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      })
    });
  }
  createOrUpdateProductType(id?: number, name?: string
  ): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post<any>(`${this.apiUrl}ProductType/CreateOrUpdate`, {
      id, name
    },{ headers: headers });
  }
  deleteProductType(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}ProductType/Delete`, { id }, { headers: headers });
  }

  getPageColor(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Color/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateColor(id?: number, ma?: string, name?: string
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Color/CreateOrUpdate`, {
      id, ma, name
    });
  }
  deleteColor(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Color/Delete`, { id }, { headers: headers });
  }

  getPageManufacturer(page: number, pageSize: number, keywords: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}Manufacturer/GetPage`, {
      page,
      pageSize,
      keywords
    });
  }
  createOrUpdateManufacturer(id?: number, name?: string
  ): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}Manufacturer/CreateOrUpdate`, {
      id,name
    });
  }
  deleteManufacturer(id: number): Observable<any> {
    const token = this.accountService.getAccessToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}Manufacturer/Delete`, { id }, { headers: headers });
  } 
  deleteAddress(id: number): Observable<any> {
    return this.http.post(`${this.apiUrl}Address/Delete`, { id });
  }
}


