import { NgModule } from "@angular/core";
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { IconsProviderModule } from './icons-provider.module';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzCarouselModule } from 'ng-zorro-antd/carousel';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzAlertModule } from 'ng-zorro-antd/alert';
import { NzPopconfirmModule } from 'ng-zorro-antd/popconfirm';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzResultModule } from 'ng-zorro-antd/result';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { ReactiveFormsModule } from "@angular/forms";
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { EditorModule } from '@tinymce/tinymce-angular';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { VndFormatPipe } from 'src/app/shared/pipes/vnd-format.pipe';
import { NzQRCodeModule } from 'ng-zorro-antd/qr-code';
import { VndFormatPipe2 } from "./pipes/vnd-format.pipe2";
registerLocaleData(en);
@NgModule({
exports:[
    IconsProviderModule,
    NzLayoutModule,
    NzMenuModule,
    NzBreadCrumbModule,
    NzFormModule,
    NzButtonModule,
    NzModalModule,
    NzCardModule,
    NzCarouselModule,
    NzTableModule,
    NzInputModule,
    NzImageModule,
    NzSpinModule,
    NzAlertModule,
    NzIconModule,
    NzPopconfirmModule,
    NzInputNumberModule,
    NzSelectModule,
    NzRadioModule,
    NzDatePickerModule,
    NzDatePickerModule,
    NzBadgeModule,
    NzPaginationModule,
    NzUploadModule,
    NzMessageModule,
    NzResultModule,
    NzPopoverModule,
    ReactiveFormsModule,
    FormsModule, 
    EditorModule,
    CKEditorModule,
    NzQRCodeModule
],
 providers: [
    { provide: NZ_I18N, useValue: en_US },
      VndFormatPipe ,
      VndFormatPipe2
  ],
})
export class AntDesignModule{}