import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { MainComponent } from './main/main.component';
import { RouterModule } from '@angular/router';
import { PublicRoutingModule } from './public-routing.module';
import { AntDesignModule } from 'src/app/ant-design.module';
import { NotfoundComponent } from './notfound/notfound.component';
import { ProductComponent } from './product/product.component';
import { CartComponent } from './cart/cart.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { DetailComponent } from './detail/detail.component';
import { CarouseleComponent } from './carousel';
import { VndFormatPipe } from '../../pipes/vnd-format.pipe'


@NgModule({
  declarations: [
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    MainComponent,
    NotfoundComponent,
    ProductComponent,
    CartComponent,
    AboutComponent,
    ContactComponent,
    DetailComponent,
    CarouseleComponent,
    VndFormatPipe 
  ],
  providers: [
    VndFormatPipe 
  ],
  imports: [
    CommonModule,
    RouterModule,
    AntDesignModule,
    PublicRoutingModule
  ]
})
export class PublicModule { }
