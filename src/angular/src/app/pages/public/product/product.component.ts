import { Component, OnInit, OnDestroy } from '@angular/core';
import { AdminService } from '../../../shared/services/admin.service';
import { PublicService } from '../../../shared/services/public.service';
import { ProductDetailDto } from '../../../shared/models/model';
import { VndFormatPipe } from '../../../shared/pipes/vnd-format.pipe';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import {
  RamDto, CpuDto, CardVGADto, HardDriveDto, ScreenDto, ColorDto,
  ProductDto, DiscountDto
} from '../../../shared/models/model';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit, OnDestroy {
  //products: ProductDetailDto[] = [];
  loadRams: RamDto[] = [];
  loadCpus: CpuDto[] = [];
  loadCardVGAs: CardVGADto[] = [];
  loadHardDrives: HardDriveDto[] = [];
  loadScreens: ScreenDto[] = [];
  loadColors: ColorDto[] = [];
  products: ProductDetailDto[] = [];
  currentPage = 1;
  pageSize = 12;
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
  private queryParamsSubscription: Subscription = new Subscription(); 
  constructor(private publicService: PublicService,
     private vndFormatPipe: VndFormatPipe,
      private route: ActivatedRoute,
      private adminService: AdminService,) { }

  ngOnInit(): void {
    this.adminService.getListCardVGA().subscribe(data => {
      this.loadCardVGAs = data.data;
    });
    this.adminService.getListCpu().subscribe(data => {
      this.loadCpus = data.data;
    });
    this.queryParamsSubscription = this.route.queryParams.subscribe(params => {
      const keywords = params['keywords'];
      if (keywords) {
        this.filters.search = keywords;
        this.loadProducts(); // Gọi lại API mỗi khi từ khóa thay đổi
      }
    });
    this.loadProducts();
  }
  ngOnDestroy(): void {
    if (this.queryParamsSubscription) {
      this.queryParamsSubscription.unsubscribe();
    }
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

  onFilterChange(): void {
    if (!this.filters.cpu) {
      this.filters.cpu = 0; // Đặt về giá trị mặc định nếu CPU bị hủy chọn
    }
    if (!this.filters.cardVGA) {
      this.filters.cardVGA = 0; // Đặt về giá trị mặc định nếu RAM bị hủy chọn
    }
    this.loadProducts();
  }

  // loadProducts(): void {
  //   this.publicService.getListProducts(this.currentPage, this.pageSize).subscribe(data => {
  //     this.products = data.data;
  //     this.totalCount = data.totalCount;
  //   });
  // }

  // onPageChange(page: number): void {
  //   this.currentPage = page;
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
}
