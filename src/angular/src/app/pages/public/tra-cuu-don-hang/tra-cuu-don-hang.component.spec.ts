import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TraCuuDonHangComponent } from './tra-cuu-don-hang.component';

describe('TraCuuDonHangComponent', () => {
  let component: TraCuuDonHangComponent;
  let fixture: ComponentFixture<TraCuuDonHangComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TraCuuDonHangComponent]
    });
    fixture = TestBed.createComponent(TraCuuDonHangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
