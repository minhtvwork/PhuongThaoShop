import { Component, OnInit } from '@angular/core';
import { PublicService } from '../../../shared/services/public.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { CartItemDto } from '../../../shared/models/model';
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
// deleteCartDetail(id: number): void {
//   this.publicService.deleteCartDetai(id).subscribe(response => {
//     this.loadCart();
//     this.nzMessageService.success('Xóa thành công');
//     console.log('Phản hồi từ server:', response);
//   }, error => {
//     this.nzMessageService.info('Xóa thất bại');
//   });
// }
// quantityChange(idCartDetail: number, event: number) {
//   this.publicService.updateQuantityCartItem(event, idCartDetail).subscribe(response => {
//     this.loadCart();
//     this.nzMessageService.success('Thay đổi số lượng thành công');
//   }, error => {
//     this.nzMessageService.info('Thay đổi số lượng thất bại');
//   });
//}
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
      // Xóa mục có id tương ứng khỏi giỏ hàng trong localStorage
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
      // Tìm kiếm và cập nhật số lượng cho mục có id tương ứng trong giỏ hàng trong localStorage
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
  if(this.createBillForm.valid) {
  console.log(this.createBillForm.value);
} else {
  this.nzMessageService.error('Vui lòng điền đầy đủ thông tin!');
}
  }
}
