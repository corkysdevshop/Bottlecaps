"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Tag = /** @class */ (function () {
    function Tag(TagText) {
        this.TagText = TagText;
        this.tagText = TagText;
    }
    return Tag;
}());
exports.Tag = Tag;
var Link = /** @class */ (function () {
    function Link(LinkText) {
        this.LinkText = LinkText;
        this.linkText = LinkText;
    }
    return Link;
}());
exports.Link = Link;
var Bottlecap = /** @class */ (function () {
    function Bottlecap(title, tags, links, profile) {
        this.title = title;
        this.tag = tags;
        this.link = links;
        this.profile = profile;
    }
    return Bottlecap;
}());
exports.Bottlecap = Bottlecap;
var Profile = /** @class */ (function () {
    function Profile(profileId) {
        this.profileId = profileId;
        this.ProfileId = profileId;
    }
    return Profile;
}());
exports.Profile = Profile;
var Space = /** @class */ (function () {
    function Space() {
    }
    return Space;
}());
exports.Space = Space;
//# sourceMappingURL=models.js.map