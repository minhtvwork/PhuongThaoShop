import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './main/main.component';
import { HomeComponent } from './home/home.component';
import { DetailComponent } from './detail/detail.component';
import { CartComponent } from './cart/cart.component';
import { ProductComponent } from './product/product.component';
import { BillComponent } from './bill/bill.component';
import { PaymentResultComponent } from './payment-result/payment-result.component';
import { FindBillComponent } from './find-bill/find-bill.component';
import { CustomerInfoComponent } from './customer-info/customer-info.component';
import { RegisterComponent } from './register/register.component';
import { DonHangComponent } from './don-hang/don-hang.component';
import { ThongTinComponent } from './thong-tin/thong-tin.component';
import { TraCuuDonHangComponent } from './tra-cuu-don-hang/tra-cuu-don-hang.component';

const routes: Routes = [
  {
    path: '', component: MainComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'laptop-moi.html', component: ProductComponent },
      { path: 'product/:id', component: DetailComponent }, 
      { path: 'hoa-don.html', component: BillComponent },
     // { path: '**', component:  CartComponent },
      { path: 'cart', component: CartComponent },
      { path: 'hoa-don', component: FindBillComponent },
      { path: 'thanh-toan-that-bai', component: PaymentResultComponent },
      { path: 'thong-tin-ca-nhan', component: CustomerInfoComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'don-hang.html', component: DonHangComponent },
      { path: 'gioi-thieu.html', component: ThongTinComponent },
      { path: 'tra-cuu-don-hang.html', component: TraCuuDonHangComponent },
      // { path: 'list-product', component: ListProductsComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule { }
