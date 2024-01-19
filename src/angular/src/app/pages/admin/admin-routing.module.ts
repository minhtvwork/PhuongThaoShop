import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SlidebarComponent } from './slidebar/slidebar.component';
import { VoucherComponent } from './voucher/voucher.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductComponent } from './product/product.component';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {
    path: '', component: DashboardComponent,
    children: [
     { path: '', component: MainComponent},
     { path: '**', component: MainComponent},
     { path: 'voucher', component: VoucherComponent},
     { path: 'product', component: ProductComponent},
     { path: 'product-detail', component: ProductDetailComponent}
    ], 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
