import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'vndFormat2'
})
export class VndFormatPipe2 implements PipeTransform {
  transform(value: number): string {
    return value.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
  }
}
