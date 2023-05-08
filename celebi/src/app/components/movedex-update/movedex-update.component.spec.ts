import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovedexUpdateComponent } from './movedex-update.component';

describe('MovedexUpdateComponent', () => {
  let component: MovedexUpdateComponent;
  let fixture: ComponentFixture<MovedexUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovedexUpdateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovedexUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
