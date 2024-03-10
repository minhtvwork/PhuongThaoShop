import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute } from '@angular/router';
import { PublicService } from '../../../shared/services/public.service';
import { ProductDetailDto } from '../../../shared/models/model';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  product!: ProductDetailDto;
  productId!: string;

  constructor(private route: ActivatedRoute, private publicService: PublicService, private router: Router) { }

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['id']; // Lấy từ route
    if (this.productId) {
      this.publicService.getProductById(this.productId).subscribe(
        (data: ProductDetailDto) => {
          this.product = data;
        },
        (error) => {
          console.error('Error fetching products:', error);
        }
      );
    }
  }
  addToCart(username: string, productCode: string): void {
    this.publicService.addProductToCart(username, productCode)
      .subscribe(
        (response) => {
            this.router.navigate(['/cart']);
          console.log('Product added to cart:', response);
          
        },
        (error) => {
          console.error('Error adding product to cart:', error);
        }
      );
  }
}
