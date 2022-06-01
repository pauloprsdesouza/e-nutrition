#!/bin/bash

set -e

basedir="$(dirname $0)/.."
solution_dir="$basedir/src"
api_project_dir="Improve.Admin.Api"
test_project_dir="Improve.Admin.Tests"

cd $solution_dir/$test_project_dir

ls

dotnet test \
  /p:CollectCoverage=true
  /p:CoverletOutputFormat=cobertura
  /p:CoverletOutput='coverage/result.json'

dotnet reportgenerator
  "-reports:coverage\coverage.cobertura.xml" \
  "-targetdir:coverage" \
  "-reporttypes:Html"
