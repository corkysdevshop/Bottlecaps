 import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from '../shared/fetch-data/fetch-data.component';
import { FeaturesModule } from '../features/features.module';
import { AuthComponent } from './auth/auth.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from '../features/private/dashboard/dashboard.component';
import { SpaceComponent } from '../features/public-facing/space/space.component';
import { MyBottlecapsComponent } from '../features/private/my-bottlecaps/my-bottlecaps.component';
import { MySpacesComponent } from '../features/private/my-spaces/my-spaces.component';
import { AddSpaceComponent } from '../features/private/my-spaces/add-space/add-space.component';
import { EditSpaceComponent } from '../features/private/my-spaces/edit-space/edit-space.component';
import { ViewSpaceComponent } from '../features/private/my-spaces/view-space/view-space.component';
import { MyBottlecapsAddComponent } from '../features/private/my-bottlecaps/my-bottlecaps-add/my-bottlecaps-add.component';
import { MyBottlecapsCollectionComponent } from '../features/private/my-bottlecaps/my-bottlecaps-collection/my-bottlecaps-collection.component';
import { MyBottlecapsEditComponent } from '../features/private/my-bottlecaps/my-bottlecaps-edit/my-bottlecaps-edit.component';
import { SettingsComponent } from './settings/settings.component';

@NgModule({
	declarations: [
		NavMenuComponent,
		HomeComponent,
		AuthComponent,
		SettingsComponent
	],
  imports: [
	  CommonModule,
	  FeaturesModule,
	  FormsModule,
	  ReactiveFormsModule,
	  RouterModule.forRoot([
		  { path: '', component: HomeComponent, pathMatch: 'full'},
		  { path: 'fetch-data', component: FetchDataComponent },
		  { path: 'dashboard', component: DashboardComponent },
		  { path: 'space', component: SpaceComponent },
		  { path: 'auth', component: AuthComponent },
		  { path: 'my-bottlecaps', component: MyBottlecapsComponent },
		  { path: 'my-spaces', component: MySpacesComponent },
		  { path: 'add-space', component: AddSpaceComponent },
		  { path: 'edit-space', component: EditSpaceComponent },
		  { path: 'view-space', component: ViewSpaceComponent },
		  { path: 'add-bottlecap', component: MyBottlecapsAddComponent },
		  { path: 'view-collection', component: MyBottlecapsCollectionComponent },
		  { path: 'edit-my-bottlecaps', component: MyBottlecapsEditComponent },
		  { path: 'settings', component: SettingsComponent },
	  ]) //TODO: REFACTOR THIS INTO ITS OWN FILE
	],
	exports: [
		RouterModule,
		NavMenuComponent
	]
})
export class CoreModule { }
