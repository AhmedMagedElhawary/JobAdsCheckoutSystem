FROM mono
ADD . /src
WORKDIR /src
RUN nuget restore -source "https://www.nuget.org/api/v2" ./JobAdsCheckoutSystem.sln
RUN xbuild /p:Configuration=Release
CMD [ "mono", "/src/JobAdsCheckoutSystem/bin/Release/JobAdsCheckoutSystem.exe" ]