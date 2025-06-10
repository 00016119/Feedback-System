import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedbackCreate } from './feedback-create';

describe('FeedbackCreate', () => {
  let component: FeedbackCreate;
  let fixture: ComponentFixture<FeedbackCreate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FeedbackCreate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeedbackCreate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
