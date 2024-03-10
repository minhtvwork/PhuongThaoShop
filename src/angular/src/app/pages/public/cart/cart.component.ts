import { Component, OnInit } from '@angular/core';
import { PublicService } from '../../../shared/services/public.service';
import { CartItemDto } from '../../../shared/models/model';
import { NzMessageService } from 'ng-zorro-antd/message';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  cartItems: CartItemDto[] = [];
  constructor(private publicService: PublicService, private nzMessageService: NzMessageService) { }
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
      this.nzMessageService.success('Xóa thàn công');
      console.log('Phản hồi từ server:', response);
    }, error => {
      this.nzMessageService.info('Xóa thất bại');
    });
  }
}
