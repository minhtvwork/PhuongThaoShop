import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../../../shared/services/admin.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SerialDto,ProductDetailDto} from 'src/app/shared/models/model';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit {

  revenueData!: any[];
  salesData!: any[];
  bestSellers!: any[];
  totalRevenue!: number;
  cancellation !: string;
  constructor(private adminService: AdminService, private router: Router, private modal: NzModalService, private nzMessageService: NzMessageService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.loadRevenue();
    this.loadSales();
    this.loadBestSellers();
  }

  loadRevenue(): void {
    // this.statisticsService.getRevenueByDate('2024-01-01', '2024-12-31')
    //   .subscribe(data => this.revenueData = data);
  }

  loadSales(): void {
    // this.statisticsService.getProductSales('2024-01-01', '2024-12-31')
    //   .subscribe(data => this.salesData = data);
  }

  loadBestSellers(): void {
    this.adminService.getBestSellers().subscribe(data => {
      this.bestSellers = data.data.listBetSellers;
      this.totalRevenue = data.data.totalRevenue;
      this.cancellation = data.data.cancellation
    });
  }
}
