import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MyBottlecapsComponent } from './my-bottlecaps/my-bottlecaps.component';
import { RouterModule } from '@angular/router';
import { MySpacesComponent } from './my-spaces/my-spaces.component';
import { AddSpaceComponent } from './my-spaces/add-space/add-space.component';
import { EditSpaceComponent } from './my-spaces/edit-space/edit-space.component';
import { SpaceNavComponent } from './my-spaces/space-nav/space-nav.component';
import { ViewSpaceComponent } from './my-spaces/view-space/view-space.component';
import { MyBottlecapsNavComponent } from './my-bottlecaps/my-bottlecaps-nav/my-bottlecaps-nav.component';
import { MyBottlecapsAddComponent } from './my-bottlecaps/my-bottlecaps-add/my-bottlecaps-add.component';
import { MyBottlecapsCollectionComponent } from './my-bottlecaps/my-bottlecaps-collection/my-bottlecaps-collection.component';
import { MyBottlecapsEditComponent } from './my-bottlecaps/my-bottlecaps-edit/my-bottlecaps-edit.component';
import { FormsModule } from '@angular/forms';
import { BottlecapsComponent } from './my-bottlecaps/bottlecaps/bottlecaps.component';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [DashboardComponent, MyBottlecapsComponent, MySpacesComponent, AddSpaceComponent, EditSpaceComponent, SpaceNavComponent, ViewSpaceComponent, MyBottlecapsNavComponent, MyBottlecapsAddComponent, MyBottlecapsCollectionComponent, MyBottlecapsEditComponent, BottlecapsComponent],
  imports: [
	  CommonModule,
	  RouterModule,
	  FormsModule,
	  SharedModule
  ]
})
export class PrivateModule { }
