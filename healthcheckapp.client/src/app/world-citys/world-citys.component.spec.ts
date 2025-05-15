import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorldCitysComponent } from './world-citys.component';

describe('WorldCitysComponent', () => {
  let component: WorldCitysComponent;
  let fixture: ComponentFixture<WorldCitysComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WorldCitysComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WorldCitysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
