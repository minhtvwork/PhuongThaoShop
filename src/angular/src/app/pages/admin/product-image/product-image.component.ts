import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../../../shared/services/admin.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductImageDto,ProductDetailDto, ImageDto } from 'src/app/shared/models/model';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-productimage',
  templateUrl: './product-image.component.html',
  styleUrls: ['./product-image.component.scss']
})
export class ProductImageComponent implements OnInit {
  isVisible = false;
  isSave = false;
  modalTitle = 'Thêm';
  listData: ProductImageDto[] = [];
  productDetails: ProductDetailDto[] = [];
  images: ImageDto [] = [];
  fbForm!: FormGroup;
  searchKeyword = '';
  constructor(private adminService: AdminService, private router: Router, private modal: NzModalService, private nzMessageService: NzMessageService, private fb: FormBuilder) { }
  ngOnInit(): void {
    this.fbForm = this.fb.group({
      id: 0,
      productDetailId: ['', [Validators.required]],
      imageId: ['', [Validators.required]],
      isIndex:[false, [Validators.required]],
    });
    this.loadData();
    this.loadCombobox();
  }
  loadData(): void {
    this.adminService.getPageProductImage(1, 99999, this.searchKeyword).subscribe(response => {
      this.listData = response.data;
    });
  }
  loadCombobox(): void {
    this.adminService.getListProductDetail().subscribe(data => {
      this.productDetails = data.data;
    });
    this.adminService.getListImage().subscribe(data => {
      this.images = data.data;
      console.log(this.images);
    });
  }
  search(): void {
    this.loadData();
  }
  create(): void {
    this.modalTitle = 'Thêm ';
    this.fbForm.reset({
      id: '0'
    });
    this.isVisible = true;
  }
  save(): void {
    if (this.fbForm.valid) {
      const obj = this.fbForm.value;
      this.isSave = true;
      this.adminService.createOrUpdateProductImage(obj.id, obj.productDetailId, obj.imageId,obj.isIndex).subscribe(
        (response: any) => {
          if (response.succeeded) {
            this.nzMessageService.success(response.messages);
            this.isSave = false;
            this.isVisible = false;
            this.loadData();
            this.fbForm.reset({ id: '0' });
          } else {
            this.nzMessageService.error(response.messages);
            this.isSave = false;
          }
        },
        (error) => {
          this.isSave = false;
          this.nzMessageService.error('Thất bại');
          console.error('API call failed:', error);
        }
      );
    }
    else {
      this.nzMessageService.error('Hãy nhập đầy đủ giá trị');
    }
  }

  close(): void {
    this.isVisible = false;
  }
  cancel(): void {
    this.nzMessageService.info('Bạn đã hủy thao tác');
  }
  edit(item: ProductImageDto): void {
    this.modalTitle = 'Sửa ';
    this.fbForm.patchValue(item);
    this.isVisible = true;
  }

  delete(id: number): void {
    this.adminService.deleteProductImage(id).subscribe(
      (response: any) => {
        console.log(response)
        if (response.succeeded) {
          this.nzMessageService.success('Thành công');
          this.loadData();
        } else {
          this.nzMessageService.error('Thất bại');
        }
      },
      (error) => {
        this.nzMessageService.error('Thất bại');
        console.error('API call failed:', error);
      }
    );
  }
}
