import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpaceComponent } from './space/space.component';
import { RouterModule } from '@angular/router';
import { TagsComponent } from './space/tags/tags.component';
import { LinksComponent } from './space/links/links.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [SpaceComponent, TagsComponent, LinksComponent],
  imports: [
    CommonModule, RouterModule, FormsModule
	],
	exports: [
		SpaceComponent
	]
})
export class PublicFacingModule { }
