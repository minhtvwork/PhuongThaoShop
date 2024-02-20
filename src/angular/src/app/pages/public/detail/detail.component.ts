import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PublicService } from '../../../services/public.service';
import { ProductDetailDto } from '../../../../app/models/model';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  product!:ProductDetailDto; // Sử dụng $ để biến này là một Observable
  // products: ProductDetailDto[] = [];
  // constructor(private publicService: PublicService) { }

  // ngOnInit(): void {
  //   this.loadProducts();
  // }

  // loadProducts(): void {
  //   this.publicService.getProducts().subscribe(
  //     (data: ProductDetailDto[]) => {
  //       this.products = data;

  //       console.log(this.products)
  //     },
  //     (error) => {
  //       console.error('Error fetching products:', error);
  //     }
  //   );
  // }
  productId!: string; // Định nghĩa biến để lưu productId

  constructor(private route: ActivatedRoute,private publicService: PublicService) { }

  ngOnInit(): void {
     this.productId = this.route.snapshot.params['id']; // Lấy productId từ route
    if (this.productId) {
      this.publicService.getProductById(this.productId).subscribe(
        (data: ProductDetailDto) => {
          this.product = data;
         //this.products = data;
  console.log(data)
         // console.log(this.products)
        },
        (error) => {
          console.error('Error fetching products:', error);
        }
      );
      //this.product = this.publicService.getProductById(this.productId);
      var x=this.publicService.getProductById(this.productId);
      console.log(x);
      //console.log(this.product)
    }
  }
}
