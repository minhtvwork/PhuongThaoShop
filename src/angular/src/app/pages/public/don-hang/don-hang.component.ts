import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { PublicService } from '../../../shared/services/public.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-don-hang',
  templateUrl: './don-hang.component.html',
  styleUrls: ['./don-hang.component.scss']
})
export class DonHangComponent implements OnInit {
  billCodes: string[] = [];

  constructor(
    private publicService: PublicService,
    private router: Router,
    private accountService: AccountService,
    private location: Location,
    private nzMessageService: NzMessageService
  ) {}

  ngOnInit(): void {
    this.loadBillCodes();
  }

  loadBillCodes(): void {
    const userId = this.accountService.getUserId();
    this.publicService.getBillByUserId(userId).subscribe(
      (response: any) => {
        console.log(response.data);
        // Assuming response.data is a list of objects with a property 'invoiceCode'
        if (response && Array.isArray(response.data)) {
          this.billCodes = response.data.map((item: any) => item.invoiceCode);
        } else {
          this.nzMessageService.warning('Không có dữ liệu hóa đơn.');
        }
      },
      (error) => {
        this.nzMessageService.error('Không thể tải dữ liệu hóa đơn.');
        console.error('Error fetching bill codes:', error);
      }
    );
  }
}
