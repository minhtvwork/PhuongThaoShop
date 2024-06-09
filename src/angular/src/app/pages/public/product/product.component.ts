import { Component,OnInit } from '@angular/core';
import { PublicService } from '../../../shared/services/public.service';
import { ProductDetailDto } from '../../../shared/models/model';
import { VndFormatPipe } from '../../../shared/pipes/vnd-format.pipe'
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent {
  products: ProductDetailDto[] = [];
  selectedValue = null;
  constructor(private publicService: PublicService,  private vndFormatPipe: VndFormatPipe) { }

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
