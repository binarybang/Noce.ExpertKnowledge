# Demo for "knowledge base" service

## Summary 
This is a demo for a solution to a niche business problem.

## Problem
Say, you have a large amount of [copies](https://en.wikipedia.org/wiki/Copy_(publishing)) for use in your product UI.

These would be put somewhere in i18n files and updated as part of CI/CD process but domain experts want to be able to edit them and quickly apply the updates to UI.
This requirement and the amount of edit requests make this too tedious to support using standard i18n mechanisms.

The solution here demonstrates how to consume the copies stored on backend in a way that:
- doesn't require constant backend adjustments
- allows minimal adjustments to front-end setup when a new value is required or existing value changes its structure.

## Getting started
1. Run backend API located in `KnowledgeBaseService` using `http` or `https` launch profile. The configured setup expects it to run on localhost:8100.
1. Run `npm install` and then `npm run start` for the `demo-frontend` project. You should be able to access the demo at http://localhost:4200 and see the examples of resolved data queries.


## Notes
- Check [entry-types.ts](demo-frontend/src/app/knowledge-base/query/entry-types.ts) and [entry-spec.ts](demo-frontend/src/app/knowledge-base/query/entry-specs.ts) to understand how query setup works.
- Check [Noce.ExpertKnowledge.WebApi.http](KnowledgeBaseService/Noce.ExpertKnowledge.WebApi/Noce.ExpertKnowledge.WebApi.http) for a sample request.
- Dummy knowledge entry spec resolver returns a value based on the requested key for simplicity.
