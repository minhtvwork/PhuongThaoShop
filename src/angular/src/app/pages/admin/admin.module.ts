import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SlidebarComponent } from './slidebar/slidebar.component';
import { AntDesignModule } from 'src/app/ant-design.module';
import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './admin-routing.module';
import { VoucherComponent } from './voucher/voucher.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductComponent } from './product/product.component';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';



@NgModule({
  declarations: [
    DashboardComponent,
    SlidebarComponent,
    VoucherComponent,
    ProductDetailComponent,
    ProductComponent,
    MainComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    AntDesignModule,
    AdminRoutingModule,
    RouterModule
  ]
})
export class AdminModule { }
