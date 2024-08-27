import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HardDriveComponent } from './hard-drive.component';

describe('HardDriveComponent', () => {
  let component: HardDriveComponent;
  let fixture: ComponentFixture<HardDriveComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HardDriveComponent]
    });
    fixture = TestBed.createComponent(HardDriveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
