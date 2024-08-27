import { Component, Input, OnInit } from '@angular/core';
import { PublicService } from '../../../shared/services/public.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { PaymentService } from 'src/app/shared/services/payment.service';
import { CartItemDto, PBillCreateCommand, ResponseDto, VoucherDto, ApiResult, PBillGetByCodeQueryDto, AddressDto } from '../../../shared/models/model';
import { NzMessageService } from 'ng-zorro-antd/message';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  radioValue = 'A';
  cartItems: CartItemDto[] = [];
  createBillForm: FormGroup;
  voucherForm: FormGroup;
  userName!: string;
  request!: PBillCreateCommand;
  loadVouchers: VoucherDto[] = [];
  address: AddressDto[] = [];
  selectedPaymentMethod!: number;
  provinces: any[] = [];
  districts: any[] = [];
  communes: any[] = [];
  constructor(
    private publicService: PublicService, private nzMessageService: NzMessageService, private fb: FormBuilder,
    private accountService: AccountService, private vnpayService: PaymentService, private router: Router, private route: ActivatedRoute) {
    this.createBillForm = this.fb.group({
      fullName: ['', [Validators.required]],
      address: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      notes: [''],
      codeVoucher: [''],
      payment: [null, [Validators.required]],
      province: [null, [Validators.required]],
      district: [null, [Validators.required]],
      commune: [null, [Validators.required]],
      provinceText: [''],
      districtText: [''],
      communeText: [''],
    });
    this.voucherForm = this.fb.group({
      codeVoucher: ['']
    });
  }
  ngOnInit(): void {
    this.loadCart();
    this.loadListVoucher();
    console.log(this.accountService.getuserName());
    this.loadAddress(this.accountService.getUserId());
    this.setFormValidators();
    this.loadProvinces();
    this.createBillForm.get('province')?.valueChanges.subscribe(provinceId => {
      this.loadDistricts(provinceId);
      this.createBillForm.get('district')?.setValue(null);
      this.communes = [];
    });

    this.createBillForm.get('district')?.valueChanges.subscribe(districtId => {
      this.loadCommunes(districtId);
      this.createBillForm.get('commune')?.setValue(null);
    });
  }
  setFormValidators(): void {
    if (this.userName) {
      this.createBillForm.get('fullName')?.clearValidators();
      this.createBillForm.get('address')?.setValidators([Validators.required]);
      this.createBillForm.get('phoneNumber')?.clearValidators();
      this.createBillForm.get('province')?.clearValidators();
      this.createBillForm.get('district')?.clearValidators();
      this.createBillForm.get('commune')?.clearValidators();
    } else {
      this.createBillForm.get('fullName')?.setValidators([Validators.required]);
      this.createBillForm.get('address')?.setValidators([Validators.required]);
      this.createBillForm.get('phoneNumber')?.setValidators([Validators.required]);
      this.createBillForm.get('province')?.setValidators([Validators.required]);
      this.createBillForm.get('district')?.setValidators([Validators.required]);
      this.createBillForm.get('commune')?.setValidators([Validators.required]);

    }
    this.createBillForm.get('fullName')?.updateValueAndValidity();
    this.createBillForm.get('address')?.updateValueAndValidity();
    this.createBillForm.get('phoneNumber')?.updateValueAndValidity();
    this.createBillForm.get('province')?.updateValueAndValidity();
    this.createBillForm.get('district')?.updateValueAndValidity();
    this.createBillForm.get('communes')?.updateValueAndValidity();
  }

  loadAddress(userId: number): void {
    this.publicService.getAddress(userId).subscribe(response => {
      console.log(response.data)
      this.address = response.data;
    });
  }
  loadCart(): void {
    this.userName = this.accountService.getuserName();
    if (this.userName) {
      this.publicService.getCartByUser().subscribe(
        (data: CartItemDto[]) => {
          this.cartItems = data;
          console.log(this.cartItems);
        },
        (error) => {
          console.error('Error fetching products:', error);
        }
      );
    } else {
      const cartItemsString = localStorage.getItem('cartItems');
      if (cartItemsString) {
        this.cartItems = JSON.parse(cartItemsString);
        
        // Duyệt qua từng sản phẩm trong giỏ hàng
        this.cartItems.forEach((item, index) => {
          this.publicService.getProductById(item.idProductDetails.toString()).subscribe(
            (data: any) => {
              // Cập nhật giá mới tạm thời
              this.cartItems[index].newPrice = data.data.newPrice;
  
              // Cập nhật lại giỏ hàng vào localStorage sau khi thay đổi giá
              localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
            },
            (error) => {
              console.error('Có lỗi xảy ra:', error);
            }
          );
        });
      }
    }
  }
  
  totalPrice(): number {
    let totalPrice = 0;
    this.cartItems.forEach(item => {
      totalPrice += item.newPrice * item.quantity;
    });
    return totalPrice;
  }
  totalQuantity(): number {
    let quantity = 0;
    this.cartItems.forEach(item => {
      quantity += item.quantity;
    });
    return quantity;
  }

  cancel(): void {
    this.nzMessageService.info('Bạn đã hủy thao tác');
  }
  deleteCartDetail(id: number): void {
    if (this.userName) {
      this.publicService.deleteCartDetai(id).subscribe(response => {
        this.loadCart();
        this.nzMessageService.success('Xóa thành công');
      }, error => {
        this.nzMessageService.info('Xóa thất bại');
      });
    } else {
      const cartItemsString = localStorage.getItem('cartItems');
      if (cartItemsString) {
        let cartItems: CartItemDto[] = JSON.parse(cartItemsString);
        const index = cartItems.findIndex(item => item.id === id);
        if (index !== -1) {
          cartItems.splice(index, 1);
          localStorage.setItem('cartItems', JSON.stringify(cartItems));
          this.loadCart();
          this.nzMessageService.success('Xóa thành công');
        } else {
          this.nzMessageService.info('Xóa thất bại: Mục không tồn tại trong giỏ hàng');
        }
      }
    }
  }

  quantityChange(idCartDetail: number, event: number): void {
    if (this.userName) {
      this.publicService.updateQuantityCartItem(event, idCartDetail).subscribe(response => {
        console.log(response);
        if (response.flag) {
          this.loadCart();

          this.nzMessageService.success('Thay đổi số lượng thành công');
        }
        else {
          this.loadCart();
          this.nzMessageService.error(response.message);
        }

      }, error => {
        this.nzMessageService.info('Thay đổi số lượng thất bại');
      });
    } else {

      const cartItemsString = localStorage.getItem('cartItems');
      if (cartItemsString) {
        let cartItems: CartItemDto[] = JSON.parse(cartItemsString);
        const index = cartItems.findIndex(item => item.id === idCartDetail);
        if (index !== -1) {
          cartItems[index].quantity = event;
          this.publicService.getCountById(cartItems[index].idProductDetails).subscribe(response => {
            if (event <= response) {
              localStorage.setItem('cartItems', JSON.stringify(cartItems));
              this.loadCart();
              this.nzMessageService.success('Thay đổi số lượng thành công');
            }
            else {
              this.loadCart();
              this.nzMessageService.error('Bạn chỉ có thể thay đổi tối đa: ' + response + ' sản phẩm');
            }
          });


        } else {
          this.nzMessageService.info('Thay đổi số lượng thất bại: Mục không tồn tại trong giỏ hàng');
        }
      }
    }
  }

  loadListVoucher(): void {
    this.publicService.getListVouchers().subscribe(data => {
      this.loadVouchers = data.data;
    });
  }
  paymentVnPay(name: string, amount: number, codeBill: string) {
    const orderType = 'Payment';
    const orderDescription = 'Thanh toán đơn hàng ';

    this.vnpayService.createPayment(orderType, amount, orderDescription, name, codeBill).subscribe((response: any) => {
      console.log(response);
      window.location.href = response.paymentUrl;
    });
  }
  createBill(): void {
    console.log(this.cartItems);
    console.log(this.createBillForm.value);
    const codeVoucherValue = this.voucherForm.get('codeVoucher')?.value;
    this.createBillForm.patchValue({ codeVoucher: codeVoucherValue });
    if (this.cartItems.length > 0 && this.cartItems != null) {
      if (this.createBillForm.valid) {
        this.publicService.createBill(this.createBillForm.value).subscribe(
          (response: ApiResult<PBillGetByCodeQueryDto>) => {
            if (response.isSuccessed) {
              const invoiceCode = response.resultObj.invoiceCode;
              this.publicService.getBillByInvoiceCode(invoiceCode).subscribe(
                (billResponse: any) => {
                  if (billResponse.isSuccessed) {
                    console.log(billResponse.resultObj)
                    if (billResponse.resultObj.payment == 4) {
                      this.paymentVnPay("", billResponse.resultObj.intoMoney, billResponse.resultObj.invoiceCode)
                    }
                    else {
                      this.router.navigate(['/hoa-don.html'], { state: { billData: billResponse.resultObj } });
                    }

                    if (!this.userName) {
                      localStorage.removeItem('cartItems');
                    }
                  } else {
                    console.error('Erorr:', billResponse.message);
                  }
                },
                (error) => {
                  console.error('Error:', error);
                }
              );
            } else {
              this.nzMessageService.error(response.message);
            }
          },
          (error) => {
            this.nzMessageService.error(error);
          }
        );
      } else {
        this.nzMessageService.error('Vui lòng điền đầy đủ thông tin!');
      }
    }
    else {
      this.nzMessageService.error('Bạn hãy thêm sản phẩm vào giỏ hàng trước khi đặt hàng');
    }

  }

  refreshNavbar() {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['/cart']);
    });
  }
  loadProvinces(): void {
    this.publicService.getProvinces().subscribe(data => {
      this.provinces = data.results;
    });
  }

  loadDistricts(provinceId: string): void {
    this.publicService.getDistricts(provinceId).subscribe(data => {
      this.districts = data.results;
    });
  }

  loadCommunes(districtId: string): void {
    this.publicService.getCommunes(districtId).subscribe(data => {
      this.communes = data.results;
    });
  }
  onProvinceChange(provinceId: number): void {
    const selectedProvince = this.provinces.find(province => province.province_id === provinceId);
    this.createBillForm.patchValue({ provinceText: selectedProvince?.province_name });
  }

  onDistrictChange(districtId: number): void {
    const selectedDistrict = this.districts.find(district => district.district_id === districtId);
    this.createBillForm.patchValue({ districtText: selectedDistrict?.district_name });
  }

  onCommuneChange(communeId: number): void {
    const selectedCommune = this.communes.find(commune => commune.ward_id === communeId);
    this.createBillForm.patchValue({ communeText: selectedCommune?.ward_name });
  }
}
