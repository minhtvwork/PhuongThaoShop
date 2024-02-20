import { Component,OnInit } from '@angular/core';
import { PublicService } from '../../../services/public.service';
import { ProductDetailDto } from '../../../../app/models/model';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  products: ProductDetailDto[] = [];

  constructor(private publicService: PublicService) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.publicService.getProducts().subscribe(
      (data: ProductDetailDto[]) => {
        this.products = data;

        console.log(this.products)
      },
      (error) => {
        console.error('Error fetching products:', error);
      }
    );
  }
}
