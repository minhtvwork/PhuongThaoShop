import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SlidebarComponent } from './slidebar/slidebar.component';
import { AntDesignModule } from 'src/app/shared/ant-design.module';
import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './admin-routing.module';
import { VoucherComponent } from './voucher/voucher.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductComponent } from './product/product.component';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';
import { RamComponent } from './ram/ram.component';
import { RoleComponent } from './role/role.component';
import { ImageComponent } from './image/image.component';
import { SerialComponent } from './serial/serial.component';
import { ManageBillComponent } from './manage-bill/manage-bill.component';
import { BillDetailComponent } from './bill-detail/bill-detail.component';
import { CreateOrUpdateProductDetailComponent } from './product-detail/create-or-update.component';
import { VndFormatPipe2 } from 'src/app/shared/pipes/vnd-format.pipe2';
import { CpuComponent } from './cpu/cpu.component';
import { ScreenComponent } from './screen/screen.component';
import { ProductTypeComponent } from './product-type/product-type.component';
import { ManufacturerComponent } from './manufacturer/manufacturer.component';
import { DiscountComponent } from './discount/discount.component';
import { HardDriveComponent } from './hard-drive/hard-drive.component';
import { CardVgaComponent } from './card-vga/card-vga.component';
import { AddressComponent } from './address/address.component';
import { ColorComponent } from './color/color.component';
import { ProductImageComponent } from './product-image/product-image.component';
import { ViewBillComponent } from './view-bill/view-bill.component';
import { ManageBillV1Component } from './manage-bill-v1/manage-bill-v1.component';
import { ManageBillV2Component } from './manage-bill-v2/manage-bill-v2.component';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { StatisticsComponent } from './statistics/statistics.component';
import { BillDetailV1Component } from './bill-detail-v1/bill-detail-v1.component';
import { BillDetailV2Component } from './bill-detail-v2/bill-detail-v2.component';


@NgModule({
  declarations: [
    DashboardComponent,
    SlidebarComponent,
    VoucherComponent,
    ProductDetailComponent,
    ProductComponent,
    MainComponent,
    LoginComponent,
    RamComponent,
    RoleComponent,
    ImageComponent,
    SerialComponent,
    ManageBillComponent,
    BillDetailComponent,
    CreateOrUpdateProductDetailComponent,
    CpuComponent,
    ScreenComponent,
    ProductTypeComponent,
    ManufacturerComponent,
    DiscountComponent,
    HardDriveComponent,
    CardVgaComponent,
    AddressComponent,
    ColorComponent,
    ProductImageComponent,
    ViewBillComponent,
    ManageBillV1Component,
    ManageBillV2Component,
    StatisticsComponent,
    BillDetailV1Component,
    BillDetailV2Component
  ],
  providers: [
    VndFormatPipe2
  ],
  imports: [
    CommonModule,
    AntDesignModule,
    AdminRoutingModule,
    RouterModule,
    ZXingScannerModule
  ]
})
export class AdminModule { }
