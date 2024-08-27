import { Component,OnInit } from '@angular/core';
import { PublicService } from '../../../shared/services/public.service';
import { ProductDetailDto } from '../../../shared/models/model';
import { VndFormatPipe } from '../../../shared/pipes/vnd-format.pipe'
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  products: ProductDetailDto[] = [];
  currentPage = 1;
  pageSize = 24;
  totalCount = 0;

  filters: any = {
    manufacturer: 0,
    productType: '',
    ram: 0,
    cpu: 0,
    cardVGA: 0,
    hardDrive: '',
    screen: '',
    search: '',
    price: 0,
    sortBy: 0
  };

  constructor(private publicService: PublicService,  private vndFormatPipe: VndFormatPipe) { }

  ngOnInit(): void {
    this.loadProducts();
  }
  loadProducts(): void {
    this.publicService.getListProducts(
      this.currentPage,
      this.pageSize, 
      this.filters.search,
      this.filters.manufacturer,
      this.filters.productType,
      this.filters.ram,
      this.filters.cpu,
      this.filters.cardVGA,
      this.filters.hardDrive,
      this.filters.screen,
     
      this.filters.price,
      this.filters.sortBy
    ).subscribe({
      next: data => {
        this.products = data.data;
        console.log(this.products)
        this.totalCount = data.totalCount;
      },
      error: err => {
        console.error('Error loading products:', err);
      }
    });
  }

  onPageChange(page: number): void {
    this.currentPage = page;
    this.loadProducts();
  }
}
