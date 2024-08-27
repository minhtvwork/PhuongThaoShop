import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillDetailV2Component } from './bill-detail-v2.component';

describe('BillDetailV2Component', () => {
  let component: BillDetailV2Component;
  let fixture: ComponentFixture<BillDetailV2Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BillDetailV2Component]
    });
    fixture = TestBed.createComponent(BillDetailV2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
