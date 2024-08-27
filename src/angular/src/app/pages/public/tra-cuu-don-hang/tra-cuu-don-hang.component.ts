import { Component } from '@angular/core';

@Component({
  selector: 'app-tra-cuu-don-hang',
  templateUrl: './tra-cuu-don-hang.component.html',
  styleUrls: ['./tra-cuu-don-hang.component.scss']
})
export class TraCuuDonHangComponent {
  keyword: string = '';
  billCode: string | null = null;

  findProduct(): void {
    this.billCode = null;
    setTimeout(() => {
      if (this.keyword) {
        this.billCode = this.keyword;
      } else {
        this.billCode = null;
      }
    });
  }


}
