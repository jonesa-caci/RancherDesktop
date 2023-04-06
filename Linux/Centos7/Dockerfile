FROM scratch
LABEL org.label-schema.schema-version="1.0" \
    org.label-schema.name="CentOS Base Image" \
    maintainer="https://0cloud0.com" \
    org.label-schema.vcs-description="centos7 Base Image-minimal" \
    org.label-schema.docker.cmd="docker run centos7" \
    org.label-schema.vendor="CentOS" \
    org.label-schema.license="GPLv2" \
    org.label-schema.build-date="20190801"
ADD ./centos-7-x86_64-docker.tar.xz /
ENTRYPOINT [ "deploy.sh" ]
CMD ["/bin/bash"]
