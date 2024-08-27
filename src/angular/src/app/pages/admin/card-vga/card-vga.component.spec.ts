import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardVgaComponent } from './card-vga.component';

describe('CardVgaComponent', () => {
  let component: CardVgaComponent;
  let fixture: ComponentFixture<CardVgaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CardVgaComponent]
    });
    fixture = TestBed.createComponent(CardVgaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
