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
  product!: ProductDetailDto;
  productId!: string;

  constructor(private route: ActivatedRoute, private publicService: PublicService) { }

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
}
