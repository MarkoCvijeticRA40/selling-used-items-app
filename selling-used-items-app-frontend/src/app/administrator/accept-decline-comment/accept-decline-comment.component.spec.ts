import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptDeclineCommentComponent } from './accept-decline-comment.component';

describe('AcceptDeclineCommentComponent', () => {
  let component: AcceptDeclineCommentComponent;
  let fixture: ComponentFixture<AcceptDeclineCommentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AcceptDeclineCommentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AcceptDeclineCommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
