import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillDetailV1Component } from './bill-detail-v1.component';

describe('BillDetailV1Component', () => {
  let component: BillDetailV1Component;
  let fixture: ComponentFixture<BillDetailV1Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BillDetailV1Component]
    });
    fixture = TestBed.createComponent(BillDetailV1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
