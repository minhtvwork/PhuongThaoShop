import { Component, Input, OnInit } from '@angular/core';
import { PublicService } from '../../../shared/services/public.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { CartItemDto, RequestBillDto, ResponseDto } from '../../../shared/models/model';
import { NzMessageService } from 'ng-zorro-antd/message';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  selectedValue = null;
  radioValue = 'A';
  cartItems: CartItemDto[] = [];
  createBillForm: FormGroup;
  username!: string;
  //@Input() request: RequestBillDto | undefined;
  request!: RequestBillDto;
  constructor(
    private publicService: PublicService, private nzMessageService: NzMessageService, private fb: FormBuilder,
    private accountService: AccountService) {
    this.createBillForm = this.fb.group({
      fullName: ['', [Validators.required]],
      address: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      email: ['', [Validators.required]],
      codeVoucher: [null],
      payment: [null, [Validators.required]]
    });
    this.request = {
      fullName: 'sấ', // Cần khởi tạo giá trị mặc định cho các trường
      address: 'Hà Nội',
      phoneNumber: '',
      //email: '',
      codeVoucher: '',
      payment: 1,
      cartItem: [] // Cần khởi tạo giá trị mặc định cho các trường
    };
  }
  ngOnInit(): void {
    this.loadCart();
    console.log(this.accountService.getUsername());
  }

  loadCart(): void {
    this.username = this.accountService.getUsername();
    if (this.username) {
      this.publicService.getCartByUser().subscribe(
        (data: CartItemDto[]) => {
          this.cartItems = data;
          console.log(this.cartItems)
        },
        (error) => {
          console.error('Error fetching products:', error);
        }
      );
    }
    else {
      const cartItemsString = localStorage.getItem('cartItems');
      if (cartItemsString) {
        this.cartItems = JSON.parse(cartItemsString);
      }
    }
  }
  calculateTotalPrice(): number {
    let totalPrice = 0;
    this.cartItems.forEach(item => {
      totalPrice += item.price * item.quantity;
    });
    return totalPrice;
  }
  cancel(): void {
    this.nzMessageService.info('Bạn đã hủy thao tác');
  }
  deleteCartDetail(id: number): void {
    if (this.username) {
      this.publicService.deleteCartDetai(id).subscribe(response => {
        this.loadCart();
        this.nzMessageService.success('Xóa thành công');
        console.log('Phản hồi từ server:', response);
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
    if (this.username) {
      this.publicService.updateQuantityCartItem(event, idCartDetail).subscribe(response => {
        this.loadCart();
        this.nzMessageService.success('Thay đổi số lượng thành công');
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
          localStorage.setItem('cartItems', JSON.stringify(cartItems));
          this.loadCart();
          this.nzMessageService.success('Thay đổi số lượng thành công');
        } else {
          this.nzMessageService.info('Thay đổi số lượng thất bại: Mục không tồn tại trong giỏ hàng');
        }
      }
    }
  }

  createBill(): void {
    if (this.createBillForm.valid) {
      this.request.fullName = this.createBillForm.get('fullName')?.value;
      this.publicService.createBill(this.createBillForm.value).subscribe(
        (response: ResponseDto) => {

        },
        (error) => {

        }
      );
    } else {
      this.nzMessageService.error('Vui lòng điền đầy đủ thông tin!');
    }
  }
}
