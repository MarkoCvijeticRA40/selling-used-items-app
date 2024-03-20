import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdvertisementDisplayComponent } from './advertisement-display.component';

describe('AdvertisementDisplayComponent', () => {
  let component: AdvertisementDisplayComponent;
  let fixture: ComponentFixture<AdvertisementDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdvertisementDisplayComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdvertisementDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
