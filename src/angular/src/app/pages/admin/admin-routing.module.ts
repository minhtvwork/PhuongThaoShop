import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SlidebarComponent } from './slidebar/slidebar.component';
import { VoucherComponent } from './voucher/voucher.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductComponent } from './product/product.component';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from 'src/app/shared/services/auth-guard.service';
import { RamComponent } from './ram/ram.component';
import { RoleComponent } from './role/role.component';
import { ImageComponent } from './image/image.component';
import { SerialComponent } from './serial/serial.component';
import { ManageBillComponent } from './manage-bill/manage-bill.component';
import { BillDetailComponent } from './bill-detail/bill-detail.component';
import { CreateOrUpdateProductDetailComponent } from './product-detail/create-or-update.component';
import { CpuComponent } from './cpu/cpu.component';
import { HardDriveComponent } from './hard-drive/hard-drive.component';
import { CardVgaComponent } from './card-vga/card-vga.component';
import { DiscountComponent } from './discount/discount.component';
import { ScreenComponent } from './screen/screen.component';
import { ColorComponent } from './color/color.component';
import { AddressComponent } from './address/address.component';
import { ManufacturerComponent } from './manufacturer/manufacturer.component';
import { ProductTypeComponent } from './product-type/product-type.component';
import { ProductImageComponent } from './product-image/product-image.component';
import { ViewBillComponent } from './view-bill/view-bill.component';
import { ManageBillV2Component } from './manage-bill-v2/manage-bill-v2.component';
import { ManageBillV1Component } from './manage-bill-v1/manage-bill-v1.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { BillDetailV1Component } from './bill-detail-v1/bill-detail-v1.component';
import { BillDetailV2Component } from './bill-detail-v2/bill-detail-v2.component';
const routes: Routes = [
  {
    //canActivate: [AuthGuard],
    path: '',canActivate: [AuthGuard],  component: DashboardComponent,
    children: [
      { path: 'login', component: LoginComponent},
     { path: 'main', component: MainComponent},
     { path: 'voucher', component: VoucherComponent},
     { path: 'product', component: ProductComponent},
     { path: 'product-detail', component: ProductDetailComponent},
     { path: 'product-type', component: ProductTypeComponent},
     { path: 'ram', component: RamComponent},
     { path: 'cpu', component: CpuComponent},
     { path: 'hard-drive', component: HardDriveComponent},
     { path: 'card-vga', component: CardVgaComponent},
     { path: 'discount', component: DiscountComponent},
     { path: 'screen', component: ScreenComponent},
     { path: 'color', component: ColorComponent},
     { path: 'address', component: AddressComponent},
     { path: 'manufacturer', component: ManufacturerComponent},
     { path: 'image', component: ImageComponent},
     { path: 'product-image', component: ProductImageComponent},
     { path: 'role',component: RoleComponent},
     { path: 'serial',component: SerialComponent},
     { path: 'manage-bill',component: ManageBillComponent},
     { path: 'bill-detail/:id',component: BillDetailComponent},
     { path: 'bill-detail-v1/:id',component: BillDetailV1Component},
     { path: 'bill-detail-v2/:id',component: BillDetailV2Component},
     { path: 'product-detail-create-or-update',component: CreateOrUpdateProductDetailComponent},
     { path: 'view-bill', component: ViewBillComponent },
     { path: 'online-sales', component: ManageBillV1Component },
     { path: 'sell', component: ManageBillV2Component },
     { path: 'statistics', component: StatisticsComponent },
    ], 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
