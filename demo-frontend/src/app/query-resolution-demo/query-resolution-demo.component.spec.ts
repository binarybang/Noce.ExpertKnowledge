import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QueryResolutionDemoComponent } from './query-resolution-demo.component';

describe('QueryResolutionDemoComponent', () => {
  let component: QueryResolutionDemoComponent;
  let fixture: ComponentFixture<QueryResolutionDemoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QueryResolutionDemoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QueryResolutionDemoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
