import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { PublicService } from '../../../shared/services/public.service';
import { ProductDetailDto, CartItemDto } from '../../../shared/models/model';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  product!: ProductDetailDto;
  productId!: string;
  username!: string;
  private cartItems: CartItemDto[] = [];
  constructor(private route: ActivatedRoute, private publicService: PublicService, private router: Router,
 private accountService: AccountService,private location: Location) { }

  ngOnInit(): void {
    this.location.onUrlChange(() => {
      window.scrollTo(0, 0);
    });
    this.productId = this.route.snapshot.params['id']; // Lấy từ route
    if (this.productId) {
      this.publicService.getProductById(this.productId).subscribe(
        (data: ProductDetailDto) => {
          this.product = data;
          console.log(this.product)
        },
        (error) => {
          console.error('Có lỗi xảy ra:', error);
        }
      );
    }
  }
  addToCart(productId: string): void {
    this.username = this.accountService.getUsername()
    if (this.username) {
      this.publicService.addProductToCart(this.username, productId)
        .subscribe(
          (response) => {
            this.router.navigate(['/cart']);
          },
          (error) => {
            console.error('Xảy ra lỗi khi thêm sản phẩm vào giỏ hàng:', error);
          }
        );
    }
    else {
      function getRandomId(min: number, max: number): number {
        return Math.floor(Math.random() * (max - min + 1)) + min;
      }
      let newItem: CartItemDto = {
        id: getRandomId(1, 1000),
        userId: getRandomId(1, 1000),
        quantity: 1,
        maProductDetail: this.product.code,
        idProductDetails: Number(this.product.id),
        price: this.product.price,
      };

      const existingCartItems = localStorage.getItem('cartItems');
      if (existingCartItems) {
        this.cartItems = JSON.parse(existingCartItems);
        const existingItemIndex = this.cartItems.findIndex(item => item.idProductDetails === newItem.idProductDetails);
        if (existingItemIndex !== -1) {
          this.cartItems[existingItemIndex].quantity++;
          this.router.navigate(['/cart']);
        } else {
          this.cartItems.push(newItem);
          this.router.navigate(['/cart']);
        }

        localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
      } else {
        this.cartItems = [newItem];
        localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
        this.router.navigate(['/cart']);
      }
    }
  }
}
