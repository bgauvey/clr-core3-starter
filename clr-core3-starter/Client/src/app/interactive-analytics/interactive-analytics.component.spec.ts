import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InteractiveAnalyticsComponent } from './interactive-analytics.component';

describe('InteractiveAnalyticsComponent', () => {
  let component: InteractiveAnalyticsComponent;
  let fixture: ComponentFixture<InteractiveAnalyticsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InteractiveAnalyticsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InteractiveAnalyticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
