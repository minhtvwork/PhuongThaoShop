import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './main/main.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: '', component: MainComponent,
    children: [
      { path: '', component: HomeComponent },
      // { path: '**', component: NotfoundComponent },
      // { path: 'cart', component: CartComponent },
      // {path: 'product/:id' , component: ProductDetailComponent},
      // { path: 'list-product', component: ListProductsComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule { }
