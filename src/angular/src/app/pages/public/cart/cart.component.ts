import { Component, OnInit } from '@angular/core';
import { PublicService } from '../../../shared/services/public.service';
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
  constructor(private publicService: PublicService, private nzMessageService: NzMessageService, private fb: FormBuilder) { 
    this.createBillForm = this.fb.group({
      fullName: [null, [Validators.required]],
      address: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
      email: [null, [Validators.required]],
      codeVoucher: ["A"],
      payment: [1, [Validators.required]]
    });
  }
  ngOnInit(): void {
    this.loadCart();
  }

  loadCart(): void {
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
    this.publicService.deleteCartDetai(id).subscribe(response => {
      this.loadCart();
      this.nzMessageService.success('Xóa thành công');
      console.log('Phản hồi từ server:', response);
    }, error => {
      this.nzMessageService.info('Xóa thất bại');
    });
  }
  quantityChange(idCartDetail:number,  event: number) {
    this.publicService.updateQuantityCartItem(event,idCartDetail).subscribe(response => {
      this.loadCart();
      this.nzMessageService.success('Thay đổi số lượng thành công');
    }, error => {
      this.nzMessageService.info('Thay đổi số lượn thất bại');
    });
  }
 
 
  submitForm(): void {
    //console.log('submit', this.validateForm.value);
  }

  
}
