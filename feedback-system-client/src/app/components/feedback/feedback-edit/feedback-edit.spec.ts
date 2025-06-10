import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedbackEdit } from './feedback-edit';

describe('FeedbackEdit', () => {
  let component: FeedbackEdit;
  let fixture: ComponentFixture<FeedbackEdit>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FeedbackEdit]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeedbackEdit);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
