import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpaceComponent } from './space/space.component';
import { RouterModule } from '@angular/router';
import { TagsComponent } from './space/tags/tags.component';
import { LinksComponent } from './space/links/links.component';
import { FormsModule } from '@angular/forms';
import { SpaceAreaComponent } from './space/space-area/space-area.component';
import { MaterialModule } from '../../shared/material/material.module';

@NgModule({
  declarations: [SpaceComponent, TagsComponent, LinksComponent, SpaceAreaComponent],
  imports: [
    CommonModule, RouterModule, FormsModule, MaterialModule
	],
	exports: [
		SpaceComponent
	]
})
export class PublicFacingModule { }
