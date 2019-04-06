import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientDetailListComponent } from './client-detail-list.component';

describe('ClientDetailListComponent', () => {
  let component: ClientDetailListComponent;
  let fixture: ComponentFixture<ClientDetailListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClientDetailListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientDetailListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
