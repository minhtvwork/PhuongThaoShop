import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from '../../../shared/services/admin.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { NzMessageService } from 'ng-zorro-antd/message';
import { HttpClient } from '@angular/common/http';
import { ProductDetailGetPageDto } from 'src/app/shared/models/model';

@Component({
  selector: 'app-slidebar',
  templateUrl: './slidebar.component.html',
  styleUrls: ['./slidebar.component.scss']
})
export class SlidebarComponent implements OnInit  {
  isCollapsed = true;
  userName!: string;
  notificationInterval!: any;
  billStatus2!: number;
  constructor(private accountService: AccountService, private nzMessageService: NzMessageService,
    private adminService: AdminService,
  ) {
  }
  ngOnInit(): void {
    this.userName = this.accountService.getuserName();
    this.getNotification();
    this.notificationInterval = setInterval(() => {
      this.getNotification();
    }, 30000);
  }
  ngOnDestroy(): void {
    if (this.notificationInterval) {
      clearInterval(this.notificationInterval);
    }
  }
  getNotification(){
    this.adminService.getBillNotification().subscribe(data => {
      this.billStatus2 = data.totalStatus2;
     console.log(data)
    });
  }
  profile() {
    // Xử lý khi nhấp vào Profile
    console.log('Profile clicked');
  }

  settings() {
    // Xử lý khi nhấp vào Settings
    console.log('Settings clicked');
  }
  logOut(): void {
    this.accountService.logout();
    window.location.reload();
   }

}
